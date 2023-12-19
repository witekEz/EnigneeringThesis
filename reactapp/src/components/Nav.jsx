import React, { useState } from "react";
import ComparerHome from './ComparerHome'
import AuctionsHome from './AuctionsHome'

export default function Nav(){
    const active='nav-link active aria-current="page"'
    const unActive='nav-link'

    //hook
    const [isActive,setActive] = useState(true)
    const [activeComponent,setComponent] = useState(<ComparerHome/>)
    function handleClick(){
        setActive(!isActive)
        setComponent(changeComponent)
    }
    function changeComponent(){
        if(isActive){
            return <AuctionsHome/>
        }
        else{
            return <ComparerHome/>
        }
    }  
    return(
        <>
            <ul class="nav nav-underline justify-content-center">
                <li class="nav-item">
                    <a className={isActive?active:unActive} onClick={isActive?null:handleClick} href="#">Porównywarka</a>
                </li>
                <li class="nav-item">
                    <a className={!isActive?active:unActive}onClick={isActive?handleClick:null} href="#">Aukcje</a>
                </li>
            </ul>
            {activeComponent}
        </>
    )
}