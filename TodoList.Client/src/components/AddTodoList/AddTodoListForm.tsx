import React, { useContext, useReducer, useState } from "react";

import styleClasses from "./AddTodoListForm.module.css";
import ErrorText from "../../ui/ErrorText";
import { todoListContext } from "../../stores/TodoListContext";
import { Form as RouterForm} from 'react-router-dom';
import { Form } from "react-bootstrap";
import { Button } from "react-bootstrap";
import { Row, Col } from 'react-bootstrap';
import { redirect, useSubmit } from "react-router-dom";
import { URL } from "../../app.config";


const AddTodoListForm = () => {
  const ctx = useContext(todoListContext);
  const submit = useSubmit(); 
  const [todoTitle, setTodoTitle] = useState("");
  const [todoDescription, setTodoDescription] = useState("");
  const [startDate, setStartTodoDate] = useState(Date);
  const [endDate, setEndTodoDate] = useState(Date);
 
  const [errorText, setErrorText] = useState("");


  const handleTitleInput = (event:any) => {
    setTodoTitle(event.target.value);
  };

  const handleDescriptionInput = (event:any) => {
    setTodoDescription(event.target.value);
  };
  
  const handleStartDateInput = (event:any) => {
    setStartTodoDate(event.target.value);
  };

  const handleEndDateInput = (event:any) => {
    setEndTodoDate(event.target.value);
  };

  //Doing some form validation
  const handleAddTodoListForm = (event:any) => {
    event.preventDefault();
    console.log("Form submitted");
    if (todoTitle === "" || todoDescription === "" || !startDate || !endDate) {
      setErrorText("Fields can not be empty");
      return;
    }
    if (todoTitle === "") {
      setErrorText("please fill a title");
      return;
    }
    if (todoDescription === "") {
      setErrorText("please fill a description");
      return;
    }
    if (!startDate) {
      setErrorText("please select a date");
      return;
    }
    if (!endDate) {
      setErrorText("please select a date");
      return;
    }
    const todo = {
      name: todoTitle,
      description: todoDescription,
      startDate: startDate,
      endDate:endDate,
      createdBy:''
    };
    console.log('submitting');
    submit(todo,{method:'POST',action:'addtodo'})

    setTodoTitle("");
    setTodoDescription("");
    setStartTodoDate("");
    setEndTodoDate("");
  
  };

  return (<>
    <RouterForm onSubmit={handleAddTodoListForm}>
    <Row>
    <Form.Label>Title</Form.Label>
      <Form.Control type="text" value={todoTitle} onChange={handleTitleInput} />
  
    </Row>
    <Row>    <Form.Label>Description:</Form.Label>
      <Form.Control
        type="text"
        value={todoDescription}
        onChange={handleDescriptionInput}
      />
    </Row>
    <Row>
    <Form.Label>startDate: </Form.Label>
      <Form.Control type="date" value={startDate} onChange={handleStartDateInput} />
    </Row>
    <Row>
      <Col>
      <Form.Label>end Date: </Form.Label>
      <Form.Control type="date" value={endDate} onChange={handleEndDateInput} />
      </Col>
    </Row>
    <Row>
    <ErrorText text={errorText}></ErrorText>
      <Button type="submit" >Add</Button>
    </Row>
      </RouterForm>
  </>
  );
};

export default AddTodoListForm;


export async function action({request}:any){
  const userId = localStorage.getItem('userId');
  const token = localStorage.getItem('token');
  console.log('userId: ', userId, 'token: ',token);
  const dataForm = await request.formData()
  const todo = {name: dataForm.get('name'),
  description:dataForm.get('description'),
  startDate:dataForm.get('startDate'),
  endDate:dataForm.get('endDate'),
  createdBy:userId}
  
  const response = await fetch(`${URL}/todo`,{
    method:'POST',
    body: JSON.stringify(todo),
    headers:{
      'content-type':'application/json',
      'authorization':'Bearer ' + token
    }
  })
  if(response.ok){
    console.log('Created a todo successfully');
  }
  return redirect('/home')
}