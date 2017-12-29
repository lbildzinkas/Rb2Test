import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Track from './Track';
import TrackTable from './TrackTable';

class App extends Component {
  constructor(props){
    super(props);
    this.onAddTrack = this.onAddTrack.bind(this)
  }

  state = {
    tracks: []
  }

  onAddTrack(trackTitle, trackLength){
    this.setState((previous, props) => (
      {
        tracks: [...this.state.tracks, {trackTitle, trackLength}]
      }
    ));
  }

  render() {
    return (
      <div className="list">
            <div className="list-title">
              <h1>Rb2 Test</h1>
            </div>
            <div className="list-content">
              <div>
                <div className="management">
                  <h2 className="management-title">Track Management</h2>
                  <div className="management-section">
                    <Track onAddTrack={this.onAddTrack}/>
                    <TrackTable tracks={this.state.tracks}/>
                    <button className="calculate">Calculate</button>
                  </div>
                </div>
            </div>
          </div>
      </div>
    );
  }
}

export default App;
