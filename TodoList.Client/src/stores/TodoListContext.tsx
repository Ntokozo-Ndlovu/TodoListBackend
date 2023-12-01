import React from 'react';
import { createContext } from "react";
import { useReducer } from "react";

type props ={
children:any
}


const initialState:{todoList:[],dispatch:any} = {todoList:[], dispatch:null};
export const todoListContext = createContext(initialState);
const todoListReducer = (state:any, actions:any)=>{
    if(actions.type == 'ADD'){
        let newState = [...state];
        newState.push(actions.todo);
        return newState;
    }
    else if(actions.type == 'REMOVE'){
        let newState = state.filter((item:any)=>item.id !== actions.id) 
        return newState;
    }
    return state;
}
const TodoListContext = (props:props)=>{
    const [list, dispatch] = useReducer(todoListReducer,initialState.todoList);
    
    return <todoListContext.Provider value={{todoList:list, dispatch:dispatch}}> {props.children}</todoListContext.Provider>   
}

export default TodoListContext;