const getToken = ()=>{
    const token = localStorage.getItem('token');
    if(!token){
        return null;
    }
    return localStorage.getItem('token');
}

const getTokenDuration = ()=>{
    const nowDate = new Date();
    const tokenExpire = getTokenExpire();
    if(tokenExpire){
        const timeDiff = tokenExpire.getTime() - nowDate.getTime();
        if(timeDiff < 0){
            return 'EXPIRED';
        }
        return timeDiff;
    }
}

const getTokenExpire = ()=>{
    const dateIso:string|null= localStorage.getItem('tokenExpiration');
    if(dateIso != null)
        return new Date(dateIso);

}

const saveToken = (token:string)=>{
    localStorage.setItem('token',token);
    const tokenExpireDate = new Date();
    tokenExpireDate.setTime(tokenExpireDate.getTime() + Number(import.meta.env.VITE_APP_JWT_EXPIRATION));
    localStorage.setItem('tokenExpiration',tokenExpireDate.toISOString());
}

const clearToken = ()=>{
    localStorage.removeItem('token');
    localStorage.removeItem('tokenExpiration');
}

export {saveToken,getTokenDuration,getTokenExpire,getToken,clearToken};