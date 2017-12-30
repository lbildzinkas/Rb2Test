import React, {Component} from 'react'
import './App.css';

class Talk extends Component{
    state = {
        talkName: "",
        talkLength: 0
    }

    render(){
        return (
            <div className="talk">
                <div className="talk-title">
                    <label className="talk-title-label">Talk Name:</label>
                    <input type="text" 
                            value={this.state.talkName} 
                            onChange={talkName => this.setState({talkName: talkName.target.value})} 
                    />
                </div>
                <div className="talk-length">
                    <label className="talk-length-label">Length:</label>
                    <input type="text" 
                            value={this.state.talkLength} 
                            onChange={talkLength => this.setState({talkLength: talkLength.target.value})} 
                    />
                    <label className="talk-length-label">Minutes</label>
                </div>

                <button className="talk-add" 
                onClick={() => 
                        this.props.onAddTalk(this.state.talkName, this.state.talkLength)
                        }
                >
                    Add
                </button>
            </div>
        )
    }
}

export default Talk;