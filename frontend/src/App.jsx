import { useState } from "react";
import "./App.css";

function App() {
  const [count, setCount] = useState(0);
  // State to manage the input value and list of tasks
  const [task, setTask] = useState(""); // Current task being typed
  const [tasks, setTasks] = useState([]); // List of tasks

  // Handle input change
  const handleInputChange = (e) => {
    setTask(e.target.value); // Update the task input value
  };

  // Handle form submit to add a task
  const handleAddTask = (e) => {
    e.preventDefault();
    if (task.trim()) {
      // Add the new task to the list
      setTasks([...tasks, task]);
      setTask(""); // Clear the input field after adding
    }
  };

  // Handle task removal
  const handleRemoveTask = (index) => {
    // Remove task by index from the tasks array
    const newTasks = tasks.filter((_, i) => i !== index);
    setTasks(newTasks); // Update the tasks list
  };

  return (
    <>
      <h1>AI PROJECT</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          This is a tracker for a real time Number: {count}
        </button>
      </div>
      <div style={{ padding: "20px" }}>
        <h2>Tasks to do</h2>
        <form onSubmit={handleAddTask}>
          <input
            type="text"
            value={task}
            onChange={handleInputChange}
            placeholder="Enter a task"
          />
          <button type="submit">Add Task</button>
        </form>
        <ul>
          {tasks.map((task, index) => (
            <li key={index}>
              {task}
              <button
                onClick={() => handleRemoveTask(index)}
                style={{ marginLeft: "10px" }}
              >
                Remove
              </button>
            </li>
          ))}
        </ul>
      </div>
    </>
  );
}

export default App;
