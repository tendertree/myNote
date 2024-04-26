const generalProxy = new Proxy(() => generalProxy, {
  get(target, name) {
    if (name === Symbol.toPrimitive) {
      return () => {
        ({}).toString();
      };
    } else {
      return generalProxy();
    }
  },
});
