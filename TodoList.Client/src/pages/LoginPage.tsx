import styles from './LoginPage.module.css';
import React from 'react';
import  Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import {Form as RouterForm, redirect,json, Await} from 'react-router-dom';
import Form  from 'react-bootstrap/Form';
import Button  from 'react-bootstrap/Button';
import Col  from 'react-bootstrap/Col';
import { Image } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { useRouteError } from 'react-router-dom';
import Error  from '../components/Error';

import { saveToken } from '../util/token-manager';
import { URL } from '../app.config';

const LoginPage = (props:any)=>{
    const errors:any = useRouteError();
    if(errors){
        console.log('errors: ', errors);
    }
    return <div className={styles['main-container']}   >
        <Container className='d-flex py-5 h-100 align-items-center justify-content-center' fluid>
        <div className={styles['main-layout']}>
        
        <Row className='justify-content-center align-items-center p-2'>
            <Col className={`d-flex col-9 col-sm-7 col-md-5 col-lg-4 col-xl-3  justify-content-center ${styles['img-container']}` }>
                <div>
                <Image className={styles.img} src="https://marketplace.canva.com/EAFfyNv3EC4/2/0/800w/canva-orange-black-modern-facebook-profile-picture-nEv2Bxx4TlY.jpg" roundedCircle/>
                </div>
            </Col>
        </Row>
        <Row className='justify-content-center align-items-center h-50'>
            <Col className='col-10 col-sm-7 col-md-5 col-lg-4 col-xl-3'>
            {errors && <Error message={errors.data.message}></Error>}
            <RouterForm method='post' action='/login'>
            <Form.Group>
                <Form.Label>Email: </Form.Label>
                <Form.Control name="email" id="email" type='name'/>
            </Form.Group>
            <Form.Group className='mt-3'>
                <Form.Label>Password: </Form.Label>
                <Form.Control className={styles['input']} name="password" id="password" type='password' />
            </Form.Group>
            <Button className={`my-5 btn btn-primary btn-lg btn-block ${styles['button']}`} type="submit" >Login</Button>
            </RouterForm>
            </Col>
           </Row>
           <Row className='justify-content-center align-items-center'>
            <Col className='col-10 col-sm-7 col-md-5 col-lg-4 col-xl-3'>
            To create a new account click <Link to='/signup'> Here</Link>
            </Col>
           </Row>
           </div>
    </Container>
    </div> 
    
  ;
}

export default LoginPage;

export async function action({request}:any){
    const formData = await request.formData();
    const userLoginData = {
        email: formData.get('email'),
        password: formData.get('password')
    }
    const response = await fetch(`${URL}/auth/login`,{method:'POST',body:JSON.stringify(userLoginData) ,headers:{'Content-Type':'application/json'}});

    if(!response.ok){
        const {message} = await response.json();
        throw json({message:message},{status:response.status})
    }

    if(response){
        const {userId,token} = await response.json();
        
        localStorage.setItem('userId',userId);
        saveToken(token)

        return redirect('/home');
    }
    
    return redirect('/login')
}