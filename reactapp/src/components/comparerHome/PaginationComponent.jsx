import Pagination from 'react-bootstrap/Pagination';

function PaginationComponent({pagination, onChangePage}) {
    let totalPages = pagination.totalPages;
    let currentPage = pagination.page;

    let pageBoxes=[];
    if(currentPage>1)
    {
        pageBoxes.push(<Pagination.Prev key="prev" onClick={()=>onChangePage(currentPage-1)}/>)
    }
    for(let page = 1; page <= totalPages; page++){
        pageBoxes.push(
            <Pagination.Item key={page} data-page={page} active={page === currentPage} onClick={()=>onChangePage(page)}>
                {page}
            </Pagination.Item>
            
        )
    }
    if(currentPage< totalPages)
    {
        pageBoxes.push(<Pagination.Next key="next" onClick={()=>onChangePage(currentPage+1)}/>)
    }
  return (
    <Pagination className='paginationComponent'>{pageBoxes}</Pagination>
  );
}

export default PaginationComponent;