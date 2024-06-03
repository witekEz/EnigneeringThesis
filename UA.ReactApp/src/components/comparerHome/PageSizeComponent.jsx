import Form from 'react-bootstrap/Form';
import React from "react";

function PageSizeComponent({pageSize, onChangePageSize}){
    return(
        <Form.Select size='sm' onChange={(e)=>onChangePageSize(e.target.value)}>
            <option value={5}>5</option>
            <option value={10}>10</option>
            <option value={15}>15</option>
      </Form.Select>
    )
}
export default PageSizeComponent