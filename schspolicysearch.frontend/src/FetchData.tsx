import React, { Component } from 'react';
import update from 'immutability-helper';

interface IPolicySearchResult {
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    memberCardNumber: string;
    policyNumber: string;
}

interface IFetchDataProps { }
interface IFetchDataState {
    searchResults: IPolicySearchResult[];
    memberCardNumberInput: string;
    policyNumberInput: string;
    loading: boolean;
}

export class FetchData extends Component<IFetchDataProps, IFetchDataState> {

    constructor(props: IFetchDataProps) {
        super(props);
        this.state = {
            searchResults: [],
            loading: false,
            policyNumberInput: "",
            memberCardNumberInput: ""
        };
        this.updatePolicyNumber = this.updatePolicyNumber.bind(this);
        this.updateMemberCardNumber = this.updateMemberCardNumber.bind(this);
        this.resetForm = this.resetForm.bind(this);
        this.getSearchResults = this.getSearchResults.bind(this);
        this.renderSearchResults = this.renderSearchResults.bind(this);
    }

    renderSearchResults(results: IPolicySearchResult[]) {
        return (
            <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Date of Birth</th>
                        <th>Member Card Number</th>
                        <th>Policy Number</th>
                    </tr>
                </thead>
                <tbody>
                    {results.map(policy =>
                        <tr key={policy.policyNumber}>
                            <td>{policy.firstName}</td>
                            <td>{policy.lastName}</td>
                            <td>{policy.dateOfBirth}</td>
                            <td>{policy.memberCardNumber}</td>
                            <td>{policy.policyNumber}</td>
                        </tr>
                    )}
                </tbody>
                </table>
                </div>
        );
    }

    updatePolicyNumber(event: React.FormEvent<HTMLInputElement>) {
        this.setState(update(this.state, {
            policyNumberInput: {$set: event.currentTarget.value}
        }))
    }

    updateMemberCardNumber(event: React.FormEvent<HTMLInputElement>) {
        this.setState(update(this.state, {
            memberCardNumberInput: { $set: event.currentTarget.value }
        }))
    }

    resetForm() {
        this.setState(update(this.state, {
            memberCardNumberInput: { $set: "" },
            policyNumberInput: { $set: "" },
            searchResults: { $set: []}
        }))
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderSearchResults(this.state.searchResults);

        return (
            <div>
                <h5>Search Using</h5>
                <p>Policy Number</p>
                <input type="text" value={this.state.policyNumberInput} onChange={this.updatePolicyNumber } />
                <p>Member Card Number</p>
                <input value={this.state.memberCardNumberInput} onChange={this.updateMemberCardNumber}/>
                <div>
                    <button type="submit" onClick={this.getSearchResults}>Search</button>
                    <button type="reset" onClick={this.resetForm}>Reset</button>
                </div>
                <h1 id="tabelLabel" >Search Results</h1>
                {contents}
            </div>
        );
    }

    async getSearchResults() {
        const response = await fetch("https://localhost:7012/policysearch?" + new URLSearchParams({
            policyCardNumber: this.state.policyNumberInput,
            memberCardNumber: this.state.memberCardNumberInput
        }));
        const data = await response.json();
        this.setState(update(this.state, {
            searchResults: { $push: [data] },
            loading: { $set: false }
        }));
    }
}