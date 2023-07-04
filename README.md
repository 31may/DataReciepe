HOW TO RUN THE SOFTWARE:

Open the solution file (.sln) in Visual Studio.

Ensure that the solution configuration (e.g., Debug or Release) and target platform (e.g., x86 or x64) are set correctly for your system. You can modify these settings from the Visual Studio toolbar.

Build the solution by selecting "Build" from the Visual Studio menu and choosing "Build Solution" or by pressing Ctrl+Shift+B.

If there are no build errors, proceed to the next step. If there are build errors, review the error messages in the "Error List" window and make the necessary code fixes.

Once the build is successful, you can run the software by pressing F5 or selecting "Start Debugging" from the Debug menu.

Visual Studio will launch the application and display the main window of the GUI.

Interact with the GUI by entering ingredient names, selecting food groups, or specifying maximum calories to filter the list of recipes.

Click on the corresponding filter button to apply the filter and update the displayed recipes in the ListView.

Test different filtering scenarios and verify that the software behaves as expected.

To stop debugging and close the application, either click on the "Stop Debugging" button in the Visual Studio toolbar or close the main window of the application.

You can also compile the software into an executable file (.exe) by selecting "Build" from the Visual Studio menu and choosing "Build Solution" or "Rebuild Solution." The compiled executable can then be run independently without Visual Studio.

CHANGES TO THE FEEDBACK:

Firstly, the application was extended to support multiple recipes. The user can now enter an unlimited number of recipes and assign a name to each recipe.

Additionally, the data structures used for storing the recipes, ingredients, and steps were updated from arrays to generic collections. This allows for more flexibility and efficient manipulation of the data.

To enhance the user experience, a graphical user interface (GUI) was implemented using Windows Presentation Foundation (WPF). The GUI provides a more user-friendly interface for entering recipe details, filtering recipes, and displaying the recipe list. Controls such as text boxes, combo boxes, and buttons were used to facilitate user input and interaction.

Furthermore, a filtering feature was added to the application based on the lecturer's suggestions. The user can filter the list of recipes by entering the name of an ingredient that must be in the recipe, choosing a food group that must be in the recipe, or selecting a maximum number of calories.

These changes aim to enhance the usability, functionality, and overall experience of the application, aligning it more closely with the project requirements and providing a more robust and feature-rich solution.
