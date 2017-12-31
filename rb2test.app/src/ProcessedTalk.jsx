import React, { Component } from 'react'

const ProcessedTalk = ({ talk }) => (
    <div className="processed-talk">
        <label>
            - {talk.time} {talk.title} 
        </label>
        <label>
            {!talk.title.includes("lightning") ? talk.length : ""}
        </label>
    </div>
)

export default ProcessedTalk;