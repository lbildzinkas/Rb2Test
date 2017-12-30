import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Talk from './Talk';
import TalkTable from './TalkTable';
import * as TrackAPIWrapper from './TrackAPIWrapper';
import TrackTable from './TrackTable';

class App extends Component {
  constructor(props){
    super(props);
    this.onAddTalk = this.onAddTalk.bind(this)
    this.onSubmit = this.onSubmit.bind(this)
  }

  state = {
    talks: [],
    processedTracks: []
  }

  onAddTalk(Title, Length){
    this.setState((previous, props) => (
      {
        talks: [...this.state.talks, {Title, Length}]
      }
    ));
  }

  onSubmit(){
    TrackAPIWrapper.post(this.state.talks).then((tracks) => {
      console.log(tracks)
      this.setState({
        processedTracks: tracks
      })
    })
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
                    <Talk onAddTalk={this.onAddTalk}/>
                    <TalkTable talks={this.state.talks}/>
                    <button className="calculate" onClick={this.onSubmit}>Calculate</button>
                    {this.state.processedTracks.length > 0 &&
                    <TrackTable tracks={this.state.processedTracks} />}
                  </div>
                </div>
            </div>
          </div>
      </div>
    );
  }
}

export default App;
