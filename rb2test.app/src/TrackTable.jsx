import React, { Component } from 'react';

const TrackTable = (props) => {
        const tracksToShow = props.tracks.map(track => (
            <div key={track.trackTitle} className="track-table">
                <label className="track-table-row-name">{track.trackTitle}</label>
                <label className="track-table-row-length">{track.trackLength}</label>
            </div>
        ))
        
        return (
            <div>
               {(props.tracks.length > 0 && <div className="track-table">
                    <label className="track-table-header-name">Track Name</label>
                    <label className="track-table-header-length">Length</label>
                </div>)
               }
                {tracksToShow}
            </div>
        )
}

export default TrackTable;