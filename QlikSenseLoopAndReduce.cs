using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace QlikSenseLoopandReduce
{
    class QlikSenseLoopAndReduce
    {
        private QlikSenseJSONHelper qs;
        
        private string url;

        public QlikSenseLoopAndReduce(string url)
        {
            this.url = url;


            qs = new QlikSenseJSONHelper(url);
        }

        public bool LoopAndReduce(QlikSenseApp sourceapp, QlikSenseStream stream, string script, List<string> LoopValues)
        {

            //create as custom property with the values        
            CustomProperty LoopProperty = qs.addCustomProperty("LoopValueForApp" + sourceapp.name, LoopValues);

            List<Newapp> newapps = new List<Newapp>();

            //PHASE 1:   Make app Copies

            for (int i = 0; i < LoopValues.Count; i++)
            {
                Newapp newapp = new Newapp();
                newapp.newappname = sourceapp.name + "_" + LoopValues[i];

                //first see if this app exists and get its info
                QlikSenseApp target = qs.GetApp(newapp.newappname);
                if(target != null) 
                    newapp.oldappid = target.id;
                
                //now copy
                newapp.newappid = qs.CopyAndModifyApp(sourceapp.id, newapp.newappname, LoopProperty, LoopValues[i], script);

                //keep it for later
                newapps.Add(newapp);
            }

            //PHASE 2:   Reload the apps by creating a reload task, (Check if the apps have already been published to the stream in which case just start its task)

            foreach (Newapp newapp in newapps)
            {
                string taskID;
                taskID = qs.CreateTask(newapp.newappid, newapp.newappname, "Reload of : " + newapp.newappname);
                string executionID;
                executionID = qs.StartTask(taskID);

                newapp.taskid = taskID;
                newapp.executionid = executionID;
                
            }


            //Phase 2a:  Wait for reloads to complete

            // loop through each app, and wait on each loop until the reload completes checking every 3 seconds
            foreach (Newapp newapp in newapps)
            {
                //temporary code for handling a bug with blank start response for tasks
                if (newapp.executionid == "00000000-0000-0000-0000-000000000000")
                {
                    //just wait a few seconds then assume its ok
                    Thread.Sleep(3000);
                }
                else
                {
                    //proper code should check the execution worked ok, if not wait 3 seconds and try again
                    while (!qs.checkprogress(newapp.executionid))
                    {
                        Thread.Sleep(3000);
                    } 
                }
                               
                //once the code gets here all tasks have completed
            }                    
            

            //PHASE 3:   Publish the apps (or replace if they exist

            foreach (Newapp newapp in newapps)
            {
                if (newapp.oldappid != null)
                {
                    //if the app is already published then replace it
                    qs.Replace(newapp.newappid, newapp.oldappid);
                    //remove the un-needed copy and the task we no longer need
                    qs.Delete(newapp.newappid);  
                }
                else
                {
                    //if the app is not already published then publish it
                    qs.Publish(newapp.newappid, stream.id);
                }
            }

         
            return true;
        }

    }
}
