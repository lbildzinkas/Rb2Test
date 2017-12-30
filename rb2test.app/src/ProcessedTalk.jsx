import React, { Component } from 'react'

const ProcessedTalk = ({ talk }) => (
    <div>
        <label>
            - {talk.time} {talk.title} 
        </label>
        <label>
            {talk.length}
        </label>
    </div>
)

export default ProcessedTalk;