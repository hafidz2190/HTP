import React, { Component } from "react";
import { Select, Row, Col, Button } from 'antd';
import AdjustmentTable from './AdjustmentTable';

const Option = Select.Option;

export default class AdjustmentPage extends Component {
    render() {
        return (
            <div align='left'>
                <div className={'title'}>
                    <h1>Adjustment</h1><h4>>> overview &amp; stats</h4>
                </div>
                <div className={'section'}>
                    <Row style={{ marginBottom: 10, marginTop: 10 }}>
                        <Col span={2}>
                            NOP
                        </Col>
                        <Col span={10}>
                            <Select
                                showSearch
                                style={{ width: 450, marginLeft: 10 }}
                                placeholder="Pilih NOP"
                                optionFilterProp="children"
                                onChange={this.handleChange}
                                onFocus={this.handleFocus}
                                onBlur={this.handleBlur}
                                filterOption={(input, option) => option.props.children.toLowerCase().indexOf(input.toLowerCase()) >= 0}
                            >
                                <Option value="357801100990100007">357801100990100007 - TEST HOTEL AJA - JL. TESTING</Option>
                                <Option value="357801100990100327">357801100990100327 - Kalifornia Fried Egg - JL. DEBUGGING</Option>
                                <Option value="357801100990100997">357801100990100997 - SATE Intermediate - JL. DEVELOP</Option>
                            </Select>
                        </Col>
                    </Row>
                    <Row style={{ marginBottom: 10, marginTop: 10 }}>
                        <Col span={2}>
                            Bulan
                        </Col>
                        <Col span={10}>
                            <Select
                                showSearch
                                style={{ width: 450, marginLeft: 10 }}
                                placeholder="Pilih bulan"
                                optionFilterProp="children"
                                onChange={this.handleChange}
                                onFocus={this.handleFocus}
                                onBlur={this.handleBlur}
                                filterOption={(input, option) => option.props.children.toLowerCase().indexOf(input.toLowerCase()) >= 0}
                            >
                                <Option value="Januari">Januari</Option>
                                <Option value="Februari">Februari</Option>
                                <Option value="Maret">Maret</Option>
                            </Select>
                        </Col>
                    </Row>
                    <Row style={{ marginBottom: 10, marginTop: 10 }}>
                        <Col span={2}>
                            Tahun
                        </Col>
                        <Col span={10}>
                            <Select
                                showSearch
                                style={{ width: 450, marginLeft: 10 }}
                                placeholder="Pilih tahun"
                                optionFilterProp="children"
                                onChange={this.handleChange}
                                onFocus={this.handleFocus}
                                onBlur={this.handleBlur}
                                filterOption={(input, option) => option.props.children.toLowerCase().indexOf(input.toLowerCase()) >= 0}
                            >
                                <Option value="2016">2016</Option>
                                <Option value="2017">2017</Option>
                                <Option value="2018">2018</Option>
                            </Select>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <Button type={'primary'} icon={'search'}>Cari Data</Button>
                        </Col>
                    </Row>
                    <Row>
                        <AdjustmentTable />
                    </Row>
                </div>
            </div>
        )
    }
}
