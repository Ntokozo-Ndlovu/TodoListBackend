import React, { useContext } from "react";
import TodoListItem from "./TodoListItem";
import styleClasses from "./TodoList.module.css";

const TodoList = (props:any) => {
  let list = props.list;
  console.log('Todo: ', list);
  if(props.completed){
    list = list.filter((todo:any)=>todo.completed)
  }
  else {
    list = list.filter((todo:any)=>!todo.completed)   
  }

  //const ctx = useContext(todoListContext);
  //let list = ListTodo;
 // console.log('Context switch from list: ', ctx);
 return (
    <div className='list-group'>
      {list.map((todoItem:any) => {
        return (
          <TodoListItem
            key={todoItem.id}
            id={todoItem.id}
            title={todoItem.title}
            description={todoItem.description}
            startDate={todoItem.startDate}
            endDate={todoItem.endDate}
            onDeleteNewTodo={props.onDeleteNewTodo}
          ></TodoListItem>
        );
      })}
    </div>
  );
};

export default TodoList;
