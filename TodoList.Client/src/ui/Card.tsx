import React from 'react';
import styleClass from './Card.module.css';

type props ={
    children:any
}
const Card = (props:props)=>{
    return <div className={styleClass.card}>
    {props.children}
    </div>
}

export default Card;