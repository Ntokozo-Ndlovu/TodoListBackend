import React from "react";
import styleClasses from "./ErrorText.module.css";

type prop ={
  text:string
}

const ErrorText = (props:prop) => {
  return props.text && <div className={styleClasses.error}>{props.text}</div>;
};

export default ErrorText;
