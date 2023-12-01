import Navigation from '../ui/Navigation';
import { Outlet } from 'react-router-dom';
import stylesClasses from './MainLayout.module.css';
import React from 'react';

const MainLayout = (props:any)=>{

        return <>
        <Navigation></Navigation>
        <Outlet></Outlet></>
}


export default MainLayout;