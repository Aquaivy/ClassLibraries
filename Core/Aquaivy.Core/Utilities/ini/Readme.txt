https://github.com/cemdervis/SharpConfig


----------------------------------------------------------
[General]
# a comment
SomeString = Hello World!
SomeInteger = 10 # an inline comment
SomeFloat = 20.05
SomeBoolean = true
SomeArray = { 1, 2, 3 }
Day = Monday

[Person]
Name = Peter
Age = 50



Read these values
----------------------------------------------------------
var config = Configuration.LoadFromFile("sample.cfg");
var section = config["General"];

string someString = section["SomeString"].StringValue;
int someInteger = section["SomeInteger"].IntValue;
float someFloat = section["SomeFloat"].FloatValue;
bool someBool = section["SomeBoolean"].BoolValue;
int[] someIntArray = section["SomeArray"].IntValueArray;
string[] someStringArray = section["SomeArray"].StringValueArray;
DayOfWeek day = section["Day"].GetValue<DayOfWeek>();

// Entire user-defined objects can be created from sections and vice versa.
var person = config["Person"].ToObject<Person>();




Creating a Configuration
----------------------------------------------------------
var myConfig = new Configuration();

myConfig["Video"]["Width"].IntValue = 1920;
myConfig["Video"]["Height"].IntValue = 1080;
myConfig["Video"]["Formats"].StringValueArray = new[] { "RGB32", "RGBA32" };

int width = myConfig["Video"]["Width"].IntValue;
int height = myConfig["Video"]["Height"].IntValue;
string[] formats = myConfig["Video"]["Formats"].StringValueArray;




Loading a Configuration
----------------------------------------------------------
Configuration.LoadFromFile("myConfig.cfg");        // Load from a text-based file.
Configuration.LoadFromStream(myStream);            // Load from a text-based stream.
Configuration.LoadFromString(myString);            // Load from text (source code).
Configuration.LoadFromBinaryFile("myConfig.cfg");  // Load from a binary file.
Configuration.LoadFromBinaryStream(myStream);      // Load from a binary stream.



Saving a Configuration
----------------------------------------------------------
myConfig.SaveToFile("myConfig.cfg");        // Save to a text-based file.
myConfig.SaveToStream(myStream);            // Save to a text-based stream.
myConfig.SaveToBinaryFile("myConfig.cfg");  // Save to a binary file.
myConfig.SaveToBinaryStream(myStream);      // Save to a binary stream.