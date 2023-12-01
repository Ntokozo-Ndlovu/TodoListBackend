import { createBrowserRouter } from "react-router-dom";
import LoginPage, {action as loginAction} from "../pages/LoginPage";
import SignUpPage from "../pages/SignUpPage";
import HomePage,{loader as homeLoader} from "../pages/HomePage";
import UserProfile from "../pages/UserProfile";
import MainLayout from "../layout/MainLayout";
import {loader as logoutLoader} from '../ui/Navigation';
import {action as addTodoAction}  from "../components/AddTodoList/AddTodoListForm"
import {action as deleteTodoAction} from "../components/TodoList/TodoListItem";
import {loader as userProfileLoader, action as userProfileAction} from '../pages/UserProfile';
import {action as signUpAction } from '../pages/SignUpPage';
import { Navigate } from "react-router-dom";
import Error from "../components/Error";
import React from 'react';

const rootRouter = createBrowserRouter([
    {path:'login',element: <LoginPage/>, errorElement:<LoginPage/>,action:loginAction},
    {path:'signup', element:<SignUpPage/>, errorElement:<SignUpPage/>, action:signUpAction},
    {path:'home', element:<MainLayout/>,errorElement:<Error></Error> ,children:[
      {path:'addtodo',action:addTodoAction},
      {path:'', loader:homeLoader,element:<HomePage/>},
      {path:'userprofile', element:<UserProfile/>,loader:userProfileLoader,action:userProfileAction},
      {path:'todo',action:deleteTodoAction}
    ]},
    {path:'logout',loader:logoutLoader},
    {path:'*', element:<Navigate to='home'></Navigate>}
  ])

  export default rootRouter;