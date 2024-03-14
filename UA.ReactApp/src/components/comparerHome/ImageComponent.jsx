import { useState } from 'react';
import Carousel from 'react-bootstrap/Carousel';
import Image from 'react-bootstrap/Image';

export default function Images({ generation }) {

    const errorURL = "https://placehold.co/600x400";

    const generateImage = () => {
        if (generation.images.length > 0) {
            {
                return (
                    generation.images.map(image => (
                        <Carousel pause={'hover'}>
                            <Carousel.Item interval={4000} key={image.image}>
                                <Image className='sizeOfImage' fluid rounded key={image.id} src={`data:image/jpeg;base64,${image.image}`} />
                            </Carousel.Item>
                        </Carousel>

                    ))
                )
            }
        }
        else {
            return (
                <Carousel pause={'hover'}>
                    <Carousel.Item interval={4000}>
                        <Image className='sizeOfImage' fluid rounded  src={errorURL} />
                    </Carousel.Item>
                </Carousel>)
        }
    }
    return (
        <>
            {generateImage()}
        </>
    )
}
//data-bs-interval="false"