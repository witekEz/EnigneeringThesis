import Carousel from 'react-bootstrap/Carousel';
import Image from 'react-bootstrap/Image';

export default function Images({ generation }) {
    return (
        <>
           <Carousel pause={'hover'}>
                {generation.images.map(image => (
                    <Carousel.Item interval={4000} key={image.image}>
                        <Image className='sizeOfImage' fluid rounded key={image.id} src={`data:image/jpeg;base64,${image.image}`} />
                    </Carousel.Item>
                ))}
            </Carousel>   
        </>
    )
}
//data-bs-interval="false"