import classes from './HomePage.module.css';
import React from 'react';
import { Button, Row, Col, Container } from 'react-bootstrap';
import { useEffect, useState } from 'react';

import { AddTodoListForm , TodoList, Modal } from '../components';

import { Plus } from 'react-bootstrap-icons';
import { redirect, useLoaderData, useNavigate } from 'react-router-dom';
import mapTodoItem from '../helpers/map-todo-item';
import { clearToken, getTokenDuration, getToken } from '../util/token-manager';
import { json } from "react-router-dom";
import { URL } from '../app.config';

const HomePage = ()=>{
    const [show, setShow] = useState(false);
    const [showPage,setShowPage] = useState('NOTCOMPLETE');
    const loaderData:any = useLoaderData();
    const todoList = loaderData.data.map((item:any) => mapTodoItem(item));
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const navigate = useNavigate();

    const handleToggle = (clickedButton:any)=>{

        if(clickedButton == 'COMPLETE'){
            setShowPage('COMPLETE')
        }
        else if(clickedButton == 'NOTCOMPLETE'){
            setShowPage('NOTCOMPLETE')
        }
    }
    useEffect(()=>{
        const duration = getTokenDuration();
        console.log('duration: ', duration);
        
        if(duration !=='EXPIRED'){
            setTimeout(()=>{
            clearToken();
            navigate('/login')
        },duration)
        } 
        else {
            clearToken();
            navigate('/login')
        }

    },[getTokenDuration])

    return <> 
        <Modal show={show} handleClose={handleClose}><AddTodoListForm></AddTodoListForm></Modal>
        <div style={{height:'100vh'}}>
        <Container  className='h-100' fluid>
         <Row className="my-3">
            <Col className='d-flex justify-content-center' onClick={()=>{handleToggle('NOTCOMPLETE')}}><Button className={showPage == 'NOTCOMPLETE' ? classes['button-active'] : classes['button']}>Not Complete</Button></Col>
            <Col className='d-flex justify-content-center' onClick={()=>{handleToggle('COMPLETE')}}><Button className={showPage == 'COMPLETE' ? classes['button-active'] : classes['button']}>Completed</Button></Col>
        </Row>   
        <Row className='h-100'>
            {showPage == 'NOTCOMPLETE' && <Col><TodoList list={todoList}></TodoList></Col>} 
            {showPage == 'COMPLETE' && <Col><TodoList completed={true} list={todoList}></TodoList></Col>}
            </Row>
         </Container>
        <Button className={`${classes.floating} ${classes.circle}`} onClick={handleShow} size="lg"><Plus size={60} /></Button>
     </div>
     </>
    
}
export default HomePage;


export async function loader(){
    
    const token = getToken();
    if(!token){
        return redirect('/login');
    }

    const response = await fetch(`${URL}/todo`,{
      headers:{'content-type':'application/json',
    'authorization':`Bearer ${token}`}  
    })
    
    if(!response.ok){
        const { message } = await response.json(); 
        throw json({ message:message },{ status:response.status}) 
    }

    return response;
}