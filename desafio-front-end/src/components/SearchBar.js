function SearchBar({ search, setSearch }) {
    return (
      <input
        type="text"
        placeholder="Buscar produto..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
      />
    );
  }
  
  export default SearchBar;
  