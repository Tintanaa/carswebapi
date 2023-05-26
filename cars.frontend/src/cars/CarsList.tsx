import React, { FC, ReactElement, ReactNode, useRef, useEffect, useState } from 'react';
import { CreateCarDto, Client, CarLookupDto } from '../api/api';
import { FormControl } from 'react-bootstrap';

const apiClient = new Client('https://localhost:44397');

async function createCar(car: CreateCarDto) {
    await apiClient.create('1.0', car);
    console.log('Car is created.');
}

const CarsList: FC<{}> = (): ReactElement => {
    let textInput = useRef(null);
    const [cars, setCars] = useState<CarLookupDto[] | undefined>(undefined);

    async function getCars() {
        const carsListVm = await apiClient.getAll('1.0');
        setCars(carsListVm.cars);
    }

    useEffect(() => {
        setTimeout(getCars, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const car: CreateCarDto = {
                title: event.currentTarget.value,
            };
            createCar(car);
            event.currentTarget.value = '';
            setTimeout(getCars, 500);
        }
    };

    return (
        <div>
            Car
            <div>
                <FormControl ref={textInput} onKeyPress={handleKeyPress} />
            </div>
            <section>
                {cars?.map((car) => (
                    <div>
                        {car.title}
                    </div>))}
            </section>
        </div>
    );
};
export default CarsList;
