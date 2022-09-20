import React, { Component } from 'react';

export class Restaurants extends Component {
    static displayName = Restaurants.name;

    constructor(props) {
        super(props);
        this.state = { restaurants: [], loading: true };
    }

    componentDidMount() {
        this.populateRestaurantsData();
    }

    static renderRestaurantsData(restaurants) {
        return (
            <div>
                {restaurants.map(restaurant =>
                    <div className="card">
                        <div><center><img width="100%" className="card-image" src={restaurant.image} /></center></div>
                        <table>
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Min.</th>
                                    <th>Max.</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Wait time</td>
                                    <td>{restaurant.minWaitingTime}m</td>
                                    <td>{restaurant.maxWaitingTime}m</td>
                                </tr>
                            </tbody>
                        </table>

                        <div className="menu">
                            <div><center><img width="100%" className="card-image" src={restaurant.menu.items[0].image} /></center></div>
                            <div>Wait time: {restaurant.menu.items[0].waitingTime}</div>
                            <div>Calories: {restaurant.menu.items[0].calories}</div>
                        </div>
                    </div>
                )}
            </div>
            //<table className='table table-striped' aria-labelledby="tabelLabel">
            //    <thead>
            //        <tr>
            //            <th>Name</th>
            //        </tr>
            //    </thead>
            //    <tbody>
            //        {restaurants.map(restaurant =>
            //            <tr key={restaurant.name}>
            //                <td>{restaurant.name}</td>
            //            </tr>
            //        )}
            //    </tbody>
            //</table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Restaurants.renderRestaurantsData(this.state.restaurants);

        return (
            <div>
                <h1 id="tabelLabel" >Restaurant wait times</h1>
                <p>Check the wait times for your favorite restaurants.</p>
                {contents}
            </div>
        );
    }

    async populateRestaurantsData() {
        const response = await fetch('restaurants');
        const data = await response.json();
        this.setState({ restaurants: data.restaurants, loading: false });
    }
}
