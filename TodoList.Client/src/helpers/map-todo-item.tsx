export default (todo:any)=>{
    return {
        id:todo.id,
        title:todo.name,
        description:todo.description,
        startDate:new Date(todo.startDate),
        endDate:new Date(todo.endDate),
        completed:todo.completed
    }
}