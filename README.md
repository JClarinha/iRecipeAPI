# Release Notes - _iRecipe v1.0_

## PART I - Requirements Gathering

### Implemented functionalities: 

- For **unregistered** users:
    - Create an account.


- For registered **non-admin** users:
    - Create an account;
    - Login;
    - View dashboard, where all approved recipes are displayed;
    - Insert and remove comments in dashboard recipes;
    - Insert recipes in my favourites list from dashboard; 
    - Remove recipes from my favourites list;
    - Create a new recipe;
    - View and delete all my created recipes;
    - Logout.

- For registered **admin** users:
    - Login;
    - View dashboard, where all approved recipes are displayed;
    - Insert comments in dashboard recipes;
    - Delete comments from any user;
    - Insert recipes in my favourites list from dashboard; 
    - Remove recipes from my favourites list;
    - Create a new recipe* ;
    - View and delete all my created recipes;
    - Delete all recipes from any user;
    - Edit all the fields in recipes that are waiting for approval;
    - Validate recipes (in order to approve or reject them);
    - Update users and promote a user to admin;
    - Create a new user;
    - Logout.


#### Each recipe has : 
- A image;
- A name;
- A description;
- A category;
- Two or more ingredients;
- A preparation method;
- A level a difficulty;
- A preparation time;
- A date;
- A user;
- A state of approval.


#### Each ingredient has:
- A name;
- A quantity;
- A unit.


### Use Cases:
- My use case diagram, made in draw.io, englobes all the application functionalities for current users and admins.

> [!NOTE]
> The use case diagram is attached.


### Mockups:
- I did mockups for 5 screens - login, register, user dashboard, admin dashboard and recipes for approval - using Figma.
 
> [!NOTE]
> Link to the mockup below this document.

### Pseudo-code:
- I did the pseudocode for the following functionalities:
    - Create recipe;
    - Create new user. 

```pseudocode!=
Algorithm CreateRecipe

Var name, description, category.name, difficulty.difficultyLevel, preparation, user.name : text
Var pax, duration: number
Var ingredients : list
Var image : file
Var approval: bool
Var date: Date

Start
    Read name, description, category.name, pax, duration, difficulty.difficultyLevel, preparation, image, ingredients
        
    Get and write authenticated user
    Set date as current date
    Set approval as null

    If name is empty 
    So
        Write "Invalid name"
    End If 

    If category.name is not selected 
    So
        Write "Invalid category"
    End If

    If ingredients is empty 
    So
        Write "There must be at least 2 ingredients"
    End If
    
    If description is empty 
    So
        Write "Invalid description"
    End If
    
    If preparation is empty 
    So
        Write "Invalid preparation"
    End If
    
    If duration is empty 
    So
        Write "Invalid duration"
    End If
    
    If pax is empty 
    So
        Write "Invalid pax"
    End If

    If every validation equals true
    So
        Format payload to send
        Send payload do API endpoint to create new recipe
        If response is a success 
        So
            Write "Recipe created successfully!"
            Redirect recipes/viewall
        Else
            Write "Error creating the recipe"
        End If
    End If

End.
```


```pseudocode=!
Algorithm RegisterUser

Var name, email, password : text
Var admin : bool

Start

    Read name, email, password

    If name is empty OR name has less than 2 characters 
    So
        Write "Invalid name"
    End If

    If email is empty OR email doesn't end in .com, .pt, .net 
    So
        Write "Invalid email"
    End If

    If password is empty OR password has less than 6 characters OR password doesn't contain a CAPS character and special character 
    So
        Write "Invalid password"
    End If
    
    Set admin equals false
    
    If all validations equals true
    So
        Format payload to send
        Send payload do API endpoint to register new user
        If API response equals success SO
            Write "User sucessfully registered"
            Redirect to login page
        Else
            Write "Error registering the user"
        End If
    End If

End.

```

---

## PART II - Backend

### Implemented functionalities: 

- Creation of the model layer;
- Create and migrate models to database;
- Create persistency layer (DAL) using Entity Framework;
- Create a layer Web API
    - Is protected by authentication;
- Authentication with JSON Web Token (JWT);
- Services layer to the communication of the Web API and and the DAL layer;
- Use Swagger and postman to test the API.
- On runtime, the program identifies if there is a local database. If there isn't, it will create and migrate automatically.

---

## PART III - Frontend

### Implemented functionalities: 

- Implementing the necessary components to the website using Angular 18;
- Validating user inputs;
- Used bootstrap and css;
- One of the forms is the create recipe one;

---

## PART III - Tests and Deploy

### Tests

- Unit tests for **backend**:
    - I made 3 different unit tests for backend, which are stored in the ``` iRecipe.Tests ``` project, inside the solution.
    - One of the tests is the creation of a category (repository layer level) and the other one is for Add or Update a Unit (at service layer level) - all retrieved successfully.


- Unit tests for **frontend**:
    - I made 4 unit tests in the "ViewAllComponent" ``` viewall.component.spec.ts ``` in order to test 4 different scenerios - all retrieved successfully.


### Deploy

- I created a Repository in Azure DevOps, called iRecipe, where I divided the project into 4 sprints: Parte I - Requirements, Part II - Backend, Part III - Frontend and Part IV - Tests and Deploy.
- I also divided each sprint in issues, and in each issue several tasks to do. 
- Besides that, I configured and linked my DevOps Repos to the project on GitHub.

---

## Important Notes:
- Front-end is running Angular version 18;
- The front-end was developed having the CoreUI Angular template as a basis (see more about CoreUI on: https://coreui.io/angular/);
- The first admin user was directly created directly in the API endpoint. 
- The API was tested through Swagger and Postman.

___

## Links

- Mockups in Figma:
    - https://www.figma.com/proto/tbpz1v4vwYZe6NwnLRm2mS/IRecipe?node-id=10-397&t=qRD3wLoyXH1oZnmi-1




