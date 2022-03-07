import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Modal, ModalBody, ModalFooter } from 'reactstrap';
import './styles.css';
import api from '../../services/api';
import {format, getTime} from 'date-fns';

export default function Cars() {

    const navigate = useNavigate();

    const [cars, setCars] = useState([]);
    const [updateData, setUpdateData] = useState(true);
    const [deleteValue, setDeleteValue] = useState('');
    const [deleteModal, setDeleteModal] = useState(false);

    const openCloseDeleteModal = (id) => {
        setDeleteValue(id);
        setDeleteModal(!deleteModal);
    }

    const carGet = async () => {
        api.get('api/car')
            .then(response => {
                setCars(response.data);
            }).catch(error => {
                console.log(error);
            })
    }

    useEffect(() => {
        if (updateData) {
            carGet();
            setUpdateData(false);
        }
    }, [updateData]);

    async function editCar(id) {
        console.log(id)
        try {
            navigate(`insertCar/${id}`);
        } catch (error) {
            alert('Error!')
        }
    }

    async function deleteCar() {
        try {
                await api.delete(`api/car/${deleteValue}`);
                openCloseDeleteModal();
                setUpdateData(true);
        } catch (error) {
            alert('It could not delete the car. Try again. ')
        }
    }

    return (
        <div className="car-container">
            <br />
            <h3>Car Management</h3>
            <header className="App-header">
                <Link className="btn btn-primary" to="insertCar/null">Insert</Link>
            </header>
            <table className="table table-bordered">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Make</th>
                        <th>Model</th>
                        <th>Plate</th>
                        <th>Color</th>
                        <th>Date of Make</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {cars.map(car => (
                        <tr key={car.id}>
                            <th>{car.id}</th>
                            <th>{car.make}</th>
                            <th>{car.model}</th>
                            <th>{car.plate}</th>
                            <th>{car.color}</th>
                            <th>{format(new Date(car.makeDate), 'MM/dd/yyyy')}</th>
                            <td>
                                <button className="btn btn-primary" onClick={() => editCar(car.id)} type="button">Edit</button> {" "}
                                <button className="btn btn-danger" type="button" onClick={() => openCloseDeleteModal(car.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <Modal isOpen={deleteModal}>
                <ModalBody>
                    Are you sure you would like to delete the car?
                </ModalBody>
                <ModalFooter>
                    <button className="btn btn-danger" onClick={() => deleteCar()}>Yes</button>{"  "}
                    <button className="btn btn-secondary" onClick={() => openCloseDeleteModal()}>No</button>
                </ModalFooter>
            </Modal>

        </div>
    );
}