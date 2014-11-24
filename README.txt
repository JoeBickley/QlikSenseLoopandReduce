
Draft project to implement a QlikView 11 style Loop and Reduce into Qlik Sense.  


The code does this...

1. Lets you pick and app,  the field in the app you want to loop on, and the stream you want to publish too
2. Copies the root app
3. Modifies each apps script to insert a variable, this can be used in the script to reduce data on reload
4. Creates a task and reloads the data
5. Waits for the reload to complete
6. Publishes the app to the stream, or republishes it if its the repeat run through
7. Tags the app and uses custom properties to be used in rules for permissions contain the loop values


To use the project you will need...

1. a QlikSense Server  (1.0 or higher)
2. an app that has its script ready to use an injected variable when reloading
3. the DLLs from the Qlik Sense SDK in a version that matches your server (not included and you will need to update references in the project)


Useful points...

1.  If your source app is big you may want to empty it of data all except for the field you loop on (makes it faster)
2.  You only need to use the tool if you change your source app,  reloads of the child apps will keep them up to date
3. 	


