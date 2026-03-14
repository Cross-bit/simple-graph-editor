# Simple Graph Editor

Simple desktop application for creating and editing graphs (nodes and edges).  
The application is implemented in **C# using Windows Forms**.

The editor allows users to visually create directed and undirected graphs and export
them in several formats.

---

## Features

- Visual creation of graph nodes
- Edge insertion (directed / undirected)
- Node and edge value editing
- Dragging and deleting graph elements
- Undo / redo operations
- Customizable node and edge appearance
- Graph export options:
  - edge list
  - adjacency list
  - canvas screenshot (.jpg)

The application provides a simple UI consisting of a drawing canvas, tool panel
and a properties panel for editing graph elements. :contentReference[oaicite:0]{index=0}

---

## User Interface

The editor contains several main components:

- **Toolstrip** – main application menu
- **Canvas** – area where the graph is created
- **Info panel** – displays information for the user
- **Tools panel** – graph editing tools :contentReference[oaicite:1]{index=1}

---

## Export

Graphs can be exported as:

- **Edge list**
- **Adjacency list**
- **Canvas image (.jpg)**

Nodes are automatically assigned identifiers such as `node000`, `node001`, etc. :contentReference[oaicite:2]{index=2}

---

## Architecture

The application follows the **Model-View-Presenter (MVP)** design pattern.

Main parts of the system:

- **Models** – graph representation and data structures
- **Views** – Windows Forms UI components
- **Presenters** – application logic and state machines

Graph editing modes are handled by a **state machine** (`GraphEditorMachine`). :contentReference[oaicite:3]{index=3}

---

## Documentation

Full technical documentation (Czech):

📄 [Project documentation (PDF)](./dokumentace.pdf)

---

## License

All rights reserved.

This project is publicly visible for educational purposes only.  
Use of this code requires explicit permission from the author.

---

## Author

Ondřej Kříž
