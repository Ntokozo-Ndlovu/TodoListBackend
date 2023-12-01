import React, { useContext } from "react";
import classes from "./TodoListItem.module.css";
import { Button } from "react-bootstrap";
import { Trash } from "react-bootstrap-icons";
import { Check } from "react-bootstrap-icons";
import {format, sub} from 'date-fns'
import { redirect ,useSubmit} from "react-router-dom";
import { URL } from "../../app.config";

const TodoListItem = (props:any) => {
  const submit = useSubmit();

  const handleDeleteTodo = () => {
    submit({id:props.id},{method:'DELETE',action:'todo'})
    };
  const handleCompleted = ()=>{
    submit({id:props.id,completed:true},{method:'PATCH',action:'todo'})
    }

  return (
    <div className={`flex-column align-items-start py-1 ${classes['todo-item']}`}>
      <div className="d-flex w-100 justify-content-between">
      <h5 className="mb-1">{props.title}</h5>
      <small>
        <Button className={`ms-2 ${classes['button']}`} onClick={handleDeleteTodo}>
          <Trash color="#FFFFFF" /></Button>
          <Button className={`ms-2 ${classes['button']}`} onClick={handleCompleted}>
            <Check color="#FFFFFF"/>
            </Button></small>
    </div>
    <p className="mb-1">{props.description}</p>
    <small>{format(props.startDate,'dd MMM yyyy')} to {format(props.endDate,'dd MMM yyyy')}</small>
      </div>         
  );
};
export default TodoListItem;


export async function action({request}:any){
  const method = request.method;
  const formData = await request.formData();
  const token = localStorage.getItem('token');
  const todoId = formData.get('id');
    
  if(method == 'DELETE'){
    if(!todoId){
      throw new Error('Item does not exist')
    }
    console.log('Delete')
    const response = await fetch(`${URL}/todo/${todoId}`,{method:'DELETE',
    headers:{
    'authorization':`Bearer ${token}`,
    'content-type':'application/json'
  }
  })
    if(!response.ok){
      throw new Error('Delete error')
    }  
  }
  else if(method == 'PATCH'){
    const completed = formData.get('completed') =='true' ? true : false;
    const tempBody = {completed:completed};
    const response = await fetch(`${URL}/todo/${todoId}`,{
      method:'PATCH',
      headers:{
        'authorization':`Bearer ${token}`,
        'content-type':'application/json'
      },
      body:JSON.stringify(tempBody)
    })
    if(!response.ok){
      throw new Error('Welele fethu');
    }
  }
   return redirect('/home')
}