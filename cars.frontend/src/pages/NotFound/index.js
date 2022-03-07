import React from 'react';
import './styles.css';

export default function NotFound() {
    return (
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="error-template">
                        <h1>
                            404</h1>
                        <h2>
                            Not Found</h2>
                        <div class="error-details">
                            Page Not found
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}