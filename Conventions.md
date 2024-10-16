# Definition of done:
- You have tested your own code and checked if it works like it should.
- The code is tested and reviewed by all members of the team.
- It conforms to the conventions that are fixed.

# Github conventions:
- Main branch must not be changed at all times.
- For each sprint a new branch must be created.
- If you are working on a ticket you must create a issue from it. After a new brach needs to be created based on the current spring branch.
- You can't merge your ticket in the branch till definion of done is correct.

# Code conventions:

For the C# conventions a `.editorconfig` file has been created. This will enforce certain rules that are set. Please refere to that file for more information about the C# conventions.

## Xaml

- ### Code readability
  - Only declare 1 attribute per line and put the first attribute on the element line.
    ```xml
    <Button x:Name="MyButton" 
            Text="Hello world" 
            Foreground="Blue"  />
    ```
  - Put the x:Name or x:Key attribute first.
    ```xml
    <Button x:Name="MyButton" 
            Text="Hello world" 
            Foreground="Blue"  />
    ```
  - Put the attached properties at the begging of the element, after the x:Name or x:Key if they exist.
    ```xml
    <Button x:Name="ValidationButton"
          Grid.Column="2"
          Grid.Row="0"
          Text="Hello world" 
          TextAlignment="Center"
          />
    ```
- ### Naming
  - Always declare x:Name or x:Key with their x: namespace prefix.
    ```xml
    <Button x:Name="ValidationButton"
           Text="Hello world" 
           />
    ```
  - Suffix XAML names with a type indication.
    ```xml
    <Button x:Name="CheckoutButton"
        Text="Checkout" 
        />
    ```
  - Do not use a precise type indication suffix unless required.
    ```xml
    <StackPanel x:Name="ActionsPanel">
    ...
    </StackPanel>
    ```
  - Name only nodes used in code-behind.