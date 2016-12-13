using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace ToDoList
{
  public class Task
  {
    private int _id;  //placeholder for constructor
    private string _description; //placeholder for constructor

    public Task(string Description, int Id = 0)  //constructor for new task object
    {
      _description = Description;
      _id = Id;
    }

    public override bool Equals(System.Object otherTask) //forces overide of default behavior to make two objects with same data equal
    {
      if (!(otherTask is Task))
      {
        return false;
      }
      else
      {
        Task newTask = (Task) otherTask;
        bool idEquality = (this.GetId() == newTask.GetId());
        bool descriptionEquality = (this.GetDescription() == newTask.GetDescription()); //override for description
        return (idEquality && descriptionEquality); //override for id
      }
    }

    public int GetId() //returns description
    {
      return _id;
    }

    public string GetDescription() //returns description
    {
      return _description;
    }

    public void SetDescription(string newDescription) //sets description to new data
    {
      _description = newDescription;
    }

    public static List<Task> GetAll()
    {
      List<Task> allTasks = new List<Task>{};  //empty list to holds database objects

      SqlConnection conn = DB.Connection(); //creates a connetion object using our database location
      conn.Open();  //opens the connection

      SqlCommand cmd = new SqlCommand("SELECT * FROM tasks;", conn); //holds SQL commands
      SqlDataReader rdr = cmd.ExecuteReader(); //executes SQL commands

      while(rdr.Read())  // tells the connection when to stop executing when done
      {
        int taskId = rdr.GetInt32(0); //placeholder for retrieved info
        string taskDescription = rdr.GetString(1);  //placeholder for retrieved info
        Task newTask = new Task(taskDescription, taskId); //instantiate new object using task constructor
        allTasks.Add(newTask);  //add each object instantiated with database info into the empty list
      }

      if (rdr != null)  // if rdr stops executing
      {
        rdr.Close();  //close connection
      }
      if (conn != null) // if rdr stops executing
      {
        conn.Close(); //close connection
      }

      return allTasks; //return list of task objects generated from database info
    }

    public void Save() //GET MORE EXPLANATION ON THE PARAMETERS PART
    {
      SqlConnection conn = DB.Connection();  //makes new connection object
      conn.Open();  //opens connection

      SqlCommand cmd = new SqlCommand("INSERT INTO tasks (description) OUTPUT INSERTED.id VALUES (@TaskDescription);", conn);
                                //     update    | table |column name| returns newly created id  |   what to add  |
      SqlParameter descriptionParameter = new SqlParameter();  //creates new parameter object

      // We need to create a SqlParameter object for each parameter that we use in our SqlCommand. The ParameterName needs to match the parameter in the command string. The Value is what will replace the parameter in the command string when it is executed.

      descriptionParameter.ParameterName = "@TaskDescription";
      descriptionParameter.Value = this.GetDescription();
      cmd.Parameters.Add(descriptionParameter); // calls Add() on the cmd object, parmaters value, pases in descriptionParameter
      SqlDataReader rdr = cmd.ExecuteReader(); // executes commands

      while(rdr.Read()) //loop over database
      {
        this._id = rdr.GetInt32(0); // since the output of our query is the task's ID, we want to save that value to our instance variable
      }
      if (rdr != null) //close if done
      {
        rdr.Close();
      }
      if (conn != null) //close if done
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();  //new connection
      conn.Open();  //open connection
      SqlCommand cmd = new SqlCommand("DELETE FROM tasks;", conn); //new command object to delete all
      cmd.ExecuteNonQuery(); //execute command
      conn.Close();  //close
    }




  }
}
