import { Modal } from 'react-bootstrap';
import React from 'react';

type props = {
  show:any,
  handleClose:any,
  children:any
}
const AddTodoModal = (props:props)=>{

    return <>
      <Modal
        show={props.show}
        onHide={props.handleClose}
        backdrop="static"
        keyboard={false}
        size='lg' centered
      >
       <Modal.Header closeButton>
        <Modal.Title>Create a New Todo</Modal.Title>
    </Modal.Header>
    <Modal.Body>{props.children}</Modal.Body>
  </Modal></>
}

export default AddTodoModal;