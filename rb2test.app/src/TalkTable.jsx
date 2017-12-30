import React, { Component } from 'react';

const TalkTable = (props) => {
        console.log(props.talks)
        const talksToShow = props.talks.map(talk => (
            <div key={talk.Title} className="talk-table">
                <label className="talk-table-row-name">{talk.Title}</label>
                <label className="talk-table-row-length">{talk.Length}</label>
            </div>
        ))

        return (
            <div>
               {(props.talks.length > 0 && <div className="talk-table">
                    <label className="talk-table-header-name">Talk Title</label>
                    <label className="talk-table-header-length">Length</label>
                </div>)
               }
                {talksToShow}
            </div>
        )
}

export default TalkTable;