import React from 'react'
import { Spin } from 'antd'

const Wrapper = (props) => {
    const { isFetching, errorMessage, children } = props
    if (!!isFetching)
        return (
            <div>
                <Spin size="large" />
            </div>
        )
    if (errorMessage)
        return (
            <div className="center">
                <p>{errorMessage}</p>
            </div>
        )
    return children
}

export default Wrapper;