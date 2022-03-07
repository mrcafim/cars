import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Cars from './pages/Cars';
import InsertCar from './pages/InsertCar';
import NotFound from './pages/NotFound';

export default function AppRoutes(){
    return (
        <BrowserRouter>
           <Routes>
               <Route exact path="/" element={<Cars/>}/>
               <Route path="/"  element={<Cars/>}/>
               <Route path="/cars" element={<Cars/>}/>
               <Route path="/insertCar/:carId" element={<InsertCar/>}/>
               <Route path="/cars/insertCar/:carId" element={<InsertCar/>}/>
               <Route path="*" element={<NotFound/>}/>
            </Routes>
        </BrowserRouter>    
    );
}