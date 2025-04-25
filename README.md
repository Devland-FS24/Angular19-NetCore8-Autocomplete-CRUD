# Angular 19 .Net Core8 Autocomplete + CRUD

## Table of Contents
- [About](#about)
- [InstallationUsage](#installationusage)
- [Highlights](#highlights)
- [Contributing](#contributing)
- [License](#license)

## About
This Angular 19 app is a demo of both a CRUD and a .NET Core 8 API endpoint and an Autocomplete control. This control also implements the "debounce timer" feature which allows you to enter a string in an input text and the app will delay the search of data based on that string for 5 seconds. That was intentionally made for DEMO purposes.

## InstallationUsage

  Previous requirements:

  THE .NET 8 FRAMEWORK MUST BE INSTALLED.
  EXPLORER BY DEFAULT, GOOGLE CHROME.
  Visual Studio 2022 Community.
  Visual Studio Code.
  SQL Server 2014 or higher.
  SQL Management Studio v17.8.1 or higher.
  NodeJS v 22.6.0 for windows 10.
  Angular 19 installed locally, not globally, with npx command.
  
1. Download the ZIP file of this project.
IMPORTANT: 
        By default only the Autocomplete part of this demo works.
        Please follow the instructions in order to test the second part of this demo:
        Employee CRUD. 

WARNING: Before running the NG server, make sure you're running the Employee.Api WEB API, coming along with this demo and also make sure you have installed the DB "TestDb" on your local SQL server. You may or may not need to make some adjustments on your connection strings inside the Employee.Api.


- The CRUD part presents the classic Create-Read-Update-Delete operations for a Company's employee. The operations work by calling their corresponding APIs on an Employee.Api WEB API .NET Core 8 application.


        1. Run your NG server with the command: npx ng s

        2. Open a browser and go to the link:

                http://localhost:4200

        3. You can type the string "car_" or "count" in the input box then wait for about 5 seconds
        and you will see a list of car brands or a list of countries.



- The Autocomplete part has the following interesting features:

    1. Debounce timer: Prevents sending requests on every single
                       keypress!
    2. Input control: Implements several Angular features to give the best possible user experience, like:

        [(ngModel)] TWO WAY data BINDING,
        (ngModelChange),
        (keyup),
        (blur),
        (focus),
        [ngClass],
        (input) 


    3. List Items: Classic list-item control implementing ngClass to
                     select items. This list will be displayed only if there are items to be displayed. Items returned as response to the Request made against the endpoint used to get items from the Employee.Api WEB API .NET Core 8 application.

    4. Output EventEmitter: It is programmed to emit an event
                         whenever the Child function selectItem is called to SELECT AN ITEM.
                         The parent on the other hand will GET the notified event from the Child by implementing the Click function, whenever an item from the list item is CLICKED.

---- INSTRUCTIONS TO EXECUTE AND TEST THE Employee CRUD part:

1. Stop running the NG server by typing command: CTRL+C twice on the console.

2. Go to the file src\app\app.component.html and comment out existing lines. Then add
add the following line:

                        <router-outlet />

3. Go to the file src\app\app.component.ts and comment out this line:

            imports: [ListItemDataComponent],

 Then add add/uncomment the following line:

            imports: [RouterOutlet],

4. Run your NG server with the command: npx ng s

5. Open a browser and go to the link:

        http://localhost:4200/employee-data

6. THERE IS A CATCH! when "Adding/Editing" Employee objects:

        MAKE SURE you enter a value of 10 characters in the field "Contact No"
        AND 10 ONLY (no less, no more) or the app will not Save/Update the employee you're working on. I'm currently working on improvements regarding error messages so the user won't be left guessing what happened with his "employee" Adding/Editing.

## Highlights

     Some Angular 19 features worth noting:
    1. Angular Routes
    2. Components imports.
    3. Observables.
    4. Router Outlet.
    5. Parent-Child notifications through Event Emitter.
          
## Contributing
 This application is intended as a demo that is part of my Portfolio of apps. 
 I'll update this Portfolio with the latest technologies I have skills on as soon as possible.

## License
This project is licensed under the [MIT License](LICENSE).
