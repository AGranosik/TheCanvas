export async function speckleFetch(query: any, context: any) {
    const token: string = "9e873734857c1570aa623e5ab7905292293fc82976";
    if (token) {
      try {
        const url: string = context.state.selectedServer.url;
        const res = await fetch(`${url}/graphql`, {
          method: "POST",
          headers: {
            Authorization: "Bearer " + token,
            "Content-Type": "application/json",
          },
          // body: `{ query: ${query} }`
          body: JSON.stringify({
            query: query,
          }),
        });
        return await res.json();
      } catch (err) {
        console.error("API cal failed", err);
      }
    }
  } 