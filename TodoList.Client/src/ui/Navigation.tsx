import stylesClasses from './Navigation.module.css';
import { Nav, Navbar, Container , Button, Image } from 'react-bootstrap';
import { Link, NavLink, redirect} from 'react-router-dom';
import React from 'react';

const Navigation = ()=>{
    return<Navbar expand="lg" className="bg-body-tertiary">
    <Container fluid>
      <Navbar.Brand>Todo App</Navbar.Brand>
      <Navbar.Toggle aria-controls="navbarScroll" />
      <Navbar.Collapse id="navbarScroll">
        <Nav
          className="me-auto my-2 my-lg-0"
          style={{ maxHeight: '100px' }}
          navbarScroll
        >
          <NavLink to='/home' className={ ({isActive})=> {return isActive? stylesClasses.home:stylesClasses.disableHome}}>Home</NavLink>
          <div className='p-1'> </div>
          <NavLink to='/logout' className={ ({isActive})=> {return isActive? stylesClasses.home:stylesClasses.home}}>Logout</NavLink>
        </Nav>
          <NavLink to='userprofile' className={ ({isActive})=> {return isActive? stylesClasses.disableProfile:stylesClasses.profile}}>
          <Image height={40} width={40} src="https://marketplace.canva.com/EAFfyNv3EC4/2/0/800w/canva-orange-black-modern-facebook-profile-picture-nEv2Bxx4TlY.jpg" roundedCircle/>
          </NavLink>
         </Navbar.Collapse>
    </Container>
  </Navbar>
}

export default Navigation;


export async function loader(){
  //log out information remove data
  localStorage.removeItem('token');
  localStorage.removeItem('userId');
  console.log('We are here')
  return redirect('/login')
}