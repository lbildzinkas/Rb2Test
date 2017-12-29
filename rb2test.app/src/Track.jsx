import React, {Component} from 'react'
import './App.css';

class Track extends Component{
    state = {
        trackName: "",
        trackLength: 0
    }

    render(){
        return (
            <div className="track">
                <div className="track-title">
                    <label className="track-title-label">Track Name:</label>
                    <input type="text" 
                            value={this.state.trackName} 
                            onChange={trackName => this.setState({trackName: trackName.target.value})} 
                    />
                </div>
                <div className="track-length">
                    <label className="track-length-label">Track Length:</label>
                    <input type="text" 
                            value={this.state.trackLength} 
                            onChange={trackLength => this.setState({trackLength: trackLength.target.value})} 
                    />
                    <label className="track-length-label">Minutes</label>
                </div>

                <button className="track-add" 
                onClick={() => 
                        this.props.onAddTrack(this.state.trackName, this.state.trackLength)
                        }
                >
                    Add
                </button>
            </div>
        )
    }
}

export default Track;