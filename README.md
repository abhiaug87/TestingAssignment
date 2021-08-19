A. Framework Highlights:

- This is a page object model framework created using Selenium, Specflow & C#.
- The framework is capable of running tests on real browsers as well as in headless mode. It also supports cross browser testing (Chrome & Edge at the moment).
- The framework also has a function to capture screenshots of the page where the test fails. The screenshot folder can be accessed from ../bin/Debug directory.

B. Framework Description:

The framework is seggregated into various parts (explained below) for better understandablibity & easier maintainability.

- Scenarios Folder: Contains specflow file with the BDD user scenarios.

- Steps Folder: This contains the step definitions class file which has the logic for the user scenarios mentioned in the specflow file. This folder also has the base class whose properties are inherited in the step definitions section.

- Page objects Folder: This contains the page objects class file which contains all the element ids that are used in the project.

- Data Folder: This contains a class file which has logic for allowing the framework to read data from a json file rather than hard coding the test data into the step definition. It also contains a json file which stores all the test data that will be used by the application under test.

- Utilities Folder: This contains the following class files.

- Common Constants: This contains code for location of the browser drivers, names of the tags that are used in the SpecFlow file

- Hooks: This contains BeforeScenario & AfterScenrio functions that direct the test to perform actions before it starts & after it ends. Before starting the test checks whether it has to run the test has to run on a real browser or in headless mode depending on the tag mentioned on top of the scenario in the SpecFlow file. After the test is over, the framework captures images of any failed tests & then disposes the browser.

C. Pre-requisites & Getting Started:

- Download the edge driver version supported by your browser. Create a folder called "MicrosoftWebDriver" under "C:\Users\yourusername\AppData\Local\Temp" & add the edge driver version in this folder for the web browser to initiate. Make sure you name it as "MicrosoftWebDriver.exe"

- Download the chrome driver version supported by your browser. Create a folder called "chromedriver" under "C:\Users\yourusername\AppData\Local\Temp" & add the chrome driver version in this folder for the web browser to initiate. Make sure you name it as "chromedriver.exe"

- Create a blank file named "username.txt" under the "C:\Users\yourusername\AppData\Local\Temp" directory

- Install Microsoft visual studio 2019 (community edition will do)

- Install SpecFlow for visual studio

- Clone the github repo to your local machine

- Open the .sln file using visual studio 2019

D. Running Tests on Chrome:

- Add the tag @Chrome in SpecFlow on top of scenario every scenario. This is because specflow does not support feature level tags (https://github.com/SpecFlowOSS/SpecFlow/issues/2024)

- Create a folder called "chromedriver" under "C:\Users\yourusername\AppData\Local\Temp" & add the chrome driver version supported by your browser in this folder for the web browser to initiate. Make sure you name it as "chromedriver.exe"

- Right click on UITests in test explorer, select all the tests & click Run

E. Running Tests on Edge:

- Add the tag @Edge in SpecFlow on top of scenario every scenario. This is because specflow does not support feature level tags (https://github.com/SpecFlowOSS/SpecFlow/issues/2024)

- Create a folder called "MicrosoftWebDriver" under "C:\Users\yourusername\AppData\Local\Temp" & add the chrome driver version supported by your browser in this folder for the web browser to initiate. Make sure you name it as "MicrosoftWebDriver.exe"

- Right click on UITests in test explorer, select all the tests & click Run

F. Running Tests in Headless Mode:

- Add the tag @Headless in SpecFlow on top of scenario every scenario. This is because specflow does not support feature level tags (https://github.com/SpecFlowOSS/SpecFlow/issues/2024)

- Right click on UITests in test explorer, select all the tests & click Run
