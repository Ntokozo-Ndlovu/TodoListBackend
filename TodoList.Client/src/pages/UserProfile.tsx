import { Container } from 'react-bootstrap';
import { Row, Col, Image, Button } from 'react-bootstrap';
import { Form } from 'react-bootstrap';
import {Form as RouterForm, redirect} from 'react-router-dom';
import styleClasses from './UserProfile.module.css';
import { useLoaderData } from 'react-router-dom';
import { useRef } from 'react';
import { useSubmit } from 'react-router-dom';
import { URL } from '../app.config';
import React from 'react';

const UserProfile = ()=>{
    const submit = useSubmit();
    const nameRef = useRef<any>();
    const surnameRef = useRef<any>();

    const data:any = useLoaderData();
    const user = data.user;
    //user.username = user.username;


    const handleForm =(event:any)=>{
        const updateUser = {
            name: nameRef.current.value,
            surname: surnameRef.current.value,
         }
        submit(updateUser,{method:'PATCH',action:''})
    }
    
   return <>
    <div style={{height:'100vh'}}>
        <Container className='h-100'>
        <Row className='align-items-center h-50'>
        <Col className='d-flex align-items-center justify-content-center' style={{height:'100vh'}}>
            <div>
            <h1>{user.username}</h1>    
             <Image height={300} width={300} src="https://marketplace.canva.com/EAFfyNv3EC4/2/0/800w/canva-orange-black-modern-facebook-profile-picture-nEv2Bxx4TlY.jpg" roundedCircle/>
            </div>
           </Col>
            <Col>
                <RouterForm>
                <Form.Label >Name</Form.Label>
                <Form.Control name='name' ref={nameRef} defaultValue={user.name} type='text'/>
                
                <Form.Label >Surname</Form.Label>
                <Form.Control name='surname' ref={surnameRef} defaultValue={user.surname} type='text'/>
                
                <Form.Label >email</Form.Label>
                <Form.Control name='email' defaultValue={user.email} readOnly={true} type='text'/>
                </RouterForm>
               </Col>
        </Row>
        <Row className='align-items-center h-50'>
            <Button onClick={handleForm}>Save Changes</Button>
        </Row>
        </Container>
        </div>
    </>
}


export default UserProfile;


export async function loader(){
    const token = localStorage.getItem('token');
    const respose = await fetch(`${URL}/user`,{method:'GET',headers:{'authorization':`Bearer ${token}`}})
    if(!respose.ok){
        throw new Error('Could not fetch user profile')
    }
    return respose;
} 

export async function action({request}:any){
    //update the user information
    const token = localStorage.getItem('token');
    const formData = await request.formData();
    const body = {name:formData.get('name')};
    console.log('Body: ',body,"Token: ", token);
    const respose = await fetch(`${URL}/user`,{method:'PATCH',
    body:JSON.stringify(body),
    headers:{'authorization':`Bearer ${token}`,'Content-Type':'application/json'}})
    
    
    if(!respose.ok){
        throw new Error('Update userprofile error')
    }
    return redirect('');
}