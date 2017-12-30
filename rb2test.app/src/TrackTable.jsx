import React from 'react'
import ProcessedTalk from './ProcessedTalk';

const TrackTable = (props) => {
    const tracksRows = props.tracks.map(track => {
        const talks = track.trackedTalks.map(talk => (<ProcessedTalk key={talk.time} talk={talk}/>))
        
        return (
        <div className="track-row">
            <label className="talk-table-row-name">Track {track.id}:</label>
            <div>
                {talks}
            </div>
        </div>
    )})

    return (
        <div>
            {tracksRows}
        </div>)
}

export default TrackTable;