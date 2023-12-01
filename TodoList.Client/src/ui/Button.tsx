import React from "react";
import styleClass from "./Button.module.css";


type props = {
  className: String,
  onClick: ()=>{},
  type:"button" | "reset" | "submit",
  children:any
}
const Button = (props:props) => {
  const defaultClass = styleClass.button + (props.className || "");
  return (
    <button
      className={defaultClass}
      onClick={props.onClick || null}
      type={props.type || "button"}
    >
      {props.children}
    </button>
  );
};

export default Button;
