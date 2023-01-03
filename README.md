# TaskMaster

## Synopsis
The task tracking application is a web-based tool that allows users to create, update, and delete tasks. The application has a simple user interface that displays a list of tasks and provides form fields for creating and updating tasks. When a user performs an action on a task (e.g., creates a new task, updates an existing task), the application executes a corresponding command object.

The Command pattern is used to encapsulate the actions that can be performed on tasks as objects. This allows the application to decouple the user interface from the underlying logic for executing the actions, making it easier to add new actions or modify existing ones.

The application also includes a history feature that allows users to view a list of all the commands that have been executed, along with their respective results. This feature is implemented using the Memento pattern, which allows the application to save and restore the state of the command objects.

### How to run
```
>> run.cmd
```
