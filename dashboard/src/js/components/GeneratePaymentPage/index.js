import React, { Component } from "react";
import GeneratePaymentTable from './GeneratePaymentTable';

export default class GeneratePaymentPage extends Component {
    render() {
        return (
            <div align='left'>
                <div className={'title'}>
                    <h1>Generate Payment</h1><h4>>> generate ID pembayaran</h4>
                </div>
                <GeneratePaymentTable />
            </div>
        )
    }
}
