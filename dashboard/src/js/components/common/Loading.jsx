import React from 'react'
import { Spin } from 'antd'

const Loading  = (props) => {
    return (
        <div style={{ padding: '24px',
                background: 'rgb(255, 255, 255)',
                minHeight: 'calc(100vh - (64px + 64px))' }}>
            <Spin size="large"/>
            <p>
                {props.message ? props.message : "Loading page ..."}
            </p>
        </div>
    )
}

export default Loading;