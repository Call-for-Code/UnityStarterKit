# Unity Starter Kit - Data Visualization
This is a sample project for getting started with Unity and data visualization. It is setup to read and visualize COVID-19 data from a web based data source, convert the data into a JSON object and then parse the data to visualize in Unity in 3D, Augmented reality and Virtual reality.

## Data
The data source is https://covidtracking.com/ using their web JSON API. On the Unity side it uses JSON data format via [Newtonsoft.Json for Unity.](https://github.com/jilleJr/Newtonsoft.Json-for-Unity) For this example the data is for States and Territories in the United States and the positive test results.

### DataManager.cs
This script handles the web request to the tracking API and parses State data into an array. It uses the [UnityWebRequest API](https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.html) for querying the covidtracking API. The [StateData](https://github.com/Call-for-Code/UnityStarterKit/blob/master/Assets/Scripts/DataManager.cs#L66-L98) class handles the data returned from the web request. 

### DataUIDisplay.cs
This script handles displaying the positive cases in a UI and contains an enum of all the state codes alphabetized and ordered the same as is returned from the web request. Because of this we can cast the enum to an integer for getting the index of the ordered states.

### DataBarDisplay.cs
This script gets data from DataManger.cs and scales transforms based on a normalized value between the 5 states displayed. 
