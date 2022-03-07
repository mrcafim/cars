import React, { useEffect, useState } from 'react';
import './styles.css';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import api from '../../services/api';
import {format, getTime, parse} from 'date-fns';

export default function InsertCar() {

    const [id, setId] = useState('null');
    const [make, setMake] = useState('');
    const [model, setModel] = useState('');
    const [color, setColor] = useState('');
    const [plate, setPlate] = useState('');
    const [date, setDate] = useState('');

    const { carId } = useParams();

    const navigate = useNavigate();

    useEffect(() => {
        if (carId === 'null')
            return;
        else
            loadCar();
    }, [carId])

    async function loadCar() {
        try {

            const response = await api.get(`api/car/${carId}`);

            setId(response.data.id);
            setMake(response.data.make);
            setModel(response.data.model);
            setColor(response.data.color);
            setPlate(response.data.plate);
            setDate(response.data.makeDate);
        } catch (error) {
            alert('An error occured. Try again!');
            navigate('/cars');
        }
    }

    async function saveOrUpdate(event) {
        event.preventDefault();

        setDate(parse(date, 'yyyy-MM-dd HH:mm:ss', new Date()));
        const data = {
            make,
            model, 
            color,
            plate,
            date
        }

        try {
            if (carId === 'null') {
                console.log("teste dentro aqui");
                await api.post('api/car', data);
            }
            else {
                data.id = id;
                await api.put(`api/car/${id}`, data);
            }
        } catch (error) {
            alert('An error occured. Try again!');
        }
        navigate('/cars');
    }

    return (
        <div className="insert-car-container container-md">
            <div className="content">
                <section className="form">
                    <h1>{carId === 'null' ? 'Insert new car' : 'Update car'}</h1>
                    <Link className="back-link" to="/cars">
                        Back
                    </Link>
                </section>
                <Form onSubmit={saveOrUpdate}>  
                    <FormGroup>
                        <Label for="make">Make:</Label>
                        <Input name="make" placeholder="Make" value={make} onChange={e => setMake(e.target.value)}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="model">Model:</Label>
                        <Input name="model" placeholder="Model" value={model} onChange={e => setModel(e.target.value)}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="color">Color:</Label>
                        <Input name="color" placeholder="Color" value={color} onChange={e => setColor(e.target.value)}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="plate">Plate:</Label>
                        <Input name="plate" placeholder="Plate" value={plate} onChange={e => setPlate(e.target.value)}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="date">Make Date:</Label>
                        <Input name="date" placeholder="Make Date" value={date} onChange={e => setDate(e.target.value)}/>
                    </FormGroup>
                    <Button className="btn float-right" type="submit">{carId === 'null' ? 'Insert ' : 'Update '}</Button>
                </Form>
            </div>
        </div>
    );
}
